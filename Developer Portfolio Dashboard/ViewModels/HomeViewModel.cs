using Developer_Portfolio_Dashboard.Models;
namespace Developer_Portfolio_Dashboard.ViewModels
{
    public class HomeViewModel
    {
        public GitHubUser? user { get; set; }
        public List<Repo> Repos { get; set; }
    }
}
