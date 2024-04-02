namespace GLW_LAB1.Models
{
    public class UserRepository
    {
        public static List<User> _users = new List<User>();
        public static void addUser(User user)
        {
            _users.Add(user);
        }
        public static IEnumerable<User> Users => _users;
    }
}