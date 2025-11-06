using System.Collections.Generic;

public class CreatePrescriptionRecordDto
{
    public int PatientId { get; set; }
    public string PharmacistName { get; set; }
    public string Note { get; set; }
    public List<CreatePrescriptionItemDto> Items { get; set; } = new();
}

public class CreatePrescriptionItemDto
{
    public int PillId { get; set; }
    public int Quantity { get; set; }
}
