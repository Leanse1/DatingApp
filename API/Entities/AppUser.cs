namespace API.Entities;

public class AppUser
{
    //Term 'ID' must be primary key in our database. dont change name
    public int Id { get; set; }
    public required string UserName { get; set; }
}