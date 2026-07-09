namespace CyberSportsPortal.Data.Model.Views;

public class TournamentParticipantInfoView
{
    public int Id { get; set; }
    public int Standing { get; set; }
    public int? Place { get; set; }
    public int TeamId { get; set; }
    public string TeamName { get; set; }
}
