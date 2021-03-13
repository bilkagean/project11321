namespace api.Entities
{
    public class AppUser
    {
       public int id {get;set;}
       public string userName{get;set;}
       public byte[] PasswordHash{get;set;}
       public byte[] PasswordSalt{get;set;} 
    }
}