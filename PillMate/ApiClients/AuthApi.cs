using PillMate.DTOs;
using PillMate.Services;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillMate.ApiClients
{
    public class AuthApi : ApiService
    {
        public AuthApi() : base("auth") { }

        public async Task<bool> RegisterAsync(UserDto user)
        {
            try
            {
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //Console.WriteLine("▶ 회원가입 요청 보냄");
                //Console.WriteLine($"▶ 주소: {_httpClient.BaseAddress}{_baseUrl}/register");

                var response = await _httpClient.PostAsync($"{_baseUrl}/register", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원가입 오류: " + ex.Message);
                return false;
            }
        }

        public async Task<UserDto> LoginAsync(UserDto user)
        {
            //MessageBox.Show("📢 LoginAsync 진입 확인");

            try
            {
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //Console.WriteLine("▶ 로그인 요청 보냄");
                //Console.WriteLine($"▶ 주소: {_httpClient.BaseAddress}{_baseUrl}/login");

                var response = await _httpClient.PostAsync($"{_baseUrl}/login", content);
                if (!response.IsSuccessStatusCode)
                {
                    //Console.WriteLine($"▶ 로그인 실패: StatusCode = {response.StatusCode}");
                    return null;
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<UserDto>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인 오류: " + ex.Message);
                return null;
            }
        }
        public async Task<bool> UpdateAsync(UserDto user)
        {
            try
            {
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_baseUrl}/update", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("업데이트 오류: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAccountAsync(UserDto user)
        {
            try
            {
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/delete", content); // ✅ 변경
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("회원 탈퇴 오류: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
        {
            try
            {
                var json = JsonSerializer.Serialize(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"{_baseUrl}/password", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("비밀번호 변경 오류: " + ex.Message);
                return false;
            }
        }

    }
}
