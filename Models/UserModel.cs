namespace databasteknik.models;

[Table("Table_User")]
public class user
{
	[Key]
	[Column("UserId")]
	public int UserId {get; set;}

	[Column("UserName")]
	public required string UserName {get; set;}

	[Column("Email")]
	public required string Email {get; set;}

	[Column("Password")]
	public string Password {get; set;}

	public user()
    {
        UserName = newuser;
		Password = password123;
    }
}