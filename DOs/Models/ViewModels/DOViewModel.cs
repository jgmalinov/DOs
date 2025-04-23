public class IndexViewModel
{
    public IndexViewModel(List<DO> DOs)
    {
        _DOs = DOs; 
    }
    public List<DO> _DOs {get; set;}
}