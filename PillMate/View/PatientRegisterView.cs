﻿using System;
using System.Windows.Forms;
using PillMate.ApiClients;
using PillMate.DTO;
using System.Threading.Tasks;

namespace PillMate.View
{
    public partial class PatientRegisterView : Form
    {
        private readonly Func<Task> refreshList;

        public PatientRegisterView(Func<Task> refreshList)
        {
            InitializeComponent();
            this.refreshList = refreshList;
        }

        //private async void btnRegister_Click(object sender, EventArgs e)
        //{

        //    if (!int.TryParse(txtHwanjaAge.Text.Trim(), out int age))
        //    {
        //        MessageBox.Show("나이는 숫자로 입력해주세요.");
        //        return;
        //    }
        //    var dto = new CreatePatientDto
        //    {
        //        Hwanja_Name = txtName.Text.Trim(),
        //        Hwanja_Gender = cmbGender.SelectedItem?.ToString() ?? "",
        //        Hwanja_No = txtNo.Text.Trim(),
        //        Hwanja_Room = txtRoom.Text.Trim(),
        //        Hwanja_PhoneNumber = txtPhone.Text.Trim(),
        //        Bohoja_Name = txtGuardianName.Text.Trim(),
        //        Bohoja_PhoneNumber = txtGuardianPhone.Text.Trim(),
        //        Hwanja_Age = age
        //    };

        //    if (string.IsNullOrEmpty(dto.Hwanja_Name) || string.IsNullOrEmpty(dto.Hwanja_No))
        //    {
        //        MessageBox.Show("필수 입력 항목이 비어 있습니다. 이름과 환자 번호를 확인해주세요.");
        //        return;
        //    }

        //    var api = new PatientApi();
        //    var success = await api.AddAsync(dto);

        //    if (success)
        //    {
        //        MessageBox.Show("✅ 환자 등록이 완료되었습니다.");
        //        this.Close();  // 등록 후 창 닫기
        //        await refreshList(); // 환자 목록 새로고침
        //    }
        //    else
        //    {
        //        MessageBox.Show("❌ 등록 실패: 서버 오류");
        //    }
        //}

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtHwanjaAge.Text.Trim(), out int age))
            {
                MessageBox.Show("나이는 숫자로 입력해주세요.");
                return;
            }

            var dto = new CreatePatientDto
            {
                Hwanja_Name = txtName.Text.Trim(),
                Hwanja_Gender = cmbGender.SelectedItem?.ToString() ?? "",
                Hwanja_No = txtNo.Text.Trim(),
                Hwanja_Room = txtRoom.Text.Trim(),
                Hwanja_PhoneNumber = txtPhone.Text.Trim(),
                Bohoja_Name = txtGuardianName.Text.Trim(),
                Bohoja_PhoneNumber = txtGuardianPhone.Text.Trim(),
                Hwanja_Age = age
            };

            if (string.IsNullOrEmpty(dto.Hwanja_Name) || string.IsNullOrEmpty(dto.Hwanja_No))
            {
                MessageBox.Show("필수 입력 항목이 비어 있습니다. 이름과 환자 번호를 확인해주세요.");
                return;
            }

            var api = new PatientApi();
            var patientId = await api.AddAsync(dto);

            if (patientId.HasValue)
            {
                // BukyoungStatus 등록
                var bukApi = new BukyoungStatusApi();
                var bukDto = new CreateBukyoungStatusDto
                {
                    Hwanja_Name = dto.Hwanja_Name,
                    Hwanja_No = dto.Hwanja_No,
                    PatientId = patientId.Value,
                    Bukyoung_Chk = false, // 기본값
                    Bukyoung_At = DateTime.Now
                };

                await bukApi.AddAsync(bukDto);

                MessageBox.Show("✅ 환자 및 복용 상태 등록 완료!");
                this.Close();
                await refreshList();
            }
            else
            {
                MessageBox.Show("❌ 등록 실패: 서버 오류");
            }
        }

    }
}
