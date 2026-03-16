using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace databasteknik.models;

[Table("Table_Song")]
public class Song
{
	[Key]
	[Column("SongId")]
	public int SongId {get; set;}

	[Column("Title")]
	public required string Title {get; set;}

	[Column("Length")]
	public TimeSpan Length { get; set; } // i sekunder
}