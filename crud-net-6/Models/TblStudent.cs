using System;
using System.Collections.Generic;

namespace crud_net_6.Models;

public partial class TblStudent
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string StudentAddress { get; set; } = null!;
}
