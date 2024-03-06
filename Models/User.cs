using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string ApellidoP { get; set; } = null!;

    public string ApellidoM { get; set; } = null!;

    public string Password { get; set; } = null!;
}
