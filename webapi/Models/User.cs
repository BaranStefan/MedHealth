﻿// Models/User.cs

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }  // Storing the password hash, NOT the plain password.
}
