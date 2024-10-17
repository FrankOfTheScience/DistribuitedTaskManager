namespace DistribuitedTaskManager.Models;

public class TaskManagerTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}
