namespace BackpropagationNXOR.Models.Connections.Abstract.Base
{
    public interface IConnection
    {
        double Output { get; }
        double Input { get; }
        double Weight { get; set; }
       
    }
}
