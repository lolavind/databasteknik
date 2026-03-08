using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace databasteknik.models;

[Table("Table_Artist")]
public class Artist
{
	[Key]
	[Column("ArtistId")]
	public int ArtistId {get; set;}

	[Column("ArtistName")]
	public required string ArtistName {get; set;}

	/* public Artist(int ArtistId, string ArtistName)
    {
        ArtistId = ArtistId;
        ArtistName = ArtistName;
    } */
}