using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databasteknik.models;

[Table("Table_User")]
public class User
{
	[Key]
	[Column("UserId")]
	public int UserId {get; set;}

	[Column("UserName")]
	public  string UserName {get; set;}

	[Column("Password")]
	public  string Password {get; set;}

	[Column("Playlists")]
	public List<Playlist> Playlists { get; set; } = new List<Playlist>();

	// public User()
    // {
    //     UserName = newuser;
	// 	Password = password123;
    // }
}