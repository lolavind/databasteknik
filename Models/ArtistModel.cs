namespace databasteknik.models;

[Table("Table_Artist")]
public class artist
{
	[Key]
	[Column("ArtistId")]
	public int ArtistId {get; set;}

	[Column("ArtistName")]
	public required string ArtistName {get; set;}

	public Person(int ArtistId, string ArtistName)
    {
        ArtistId = ArtistId;
        ArtistName = ArtistName;
    }
}