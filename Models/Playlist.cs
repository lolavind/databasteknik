using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databasteknik.models;

[Table("Table_Playlist")]
public class Playlist
{
	[Key]
	[Column("PlaylistId")]
	public int PlaylistId {get; set;}

	[Column("PlaylistName")]
	public string PlaylistName {get; set;}

	[Column("Songs")]
	public List<Song> Songs { get; set; } = new List<Song>();

	
}