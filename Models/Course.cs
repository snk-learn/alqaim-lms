namespace AlQaim.Lms.Models;
public class Course
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int Duration { get; set; }
    public int Fee { get; set; }
    
}