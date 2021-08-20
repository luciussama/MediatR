using MediatR;

public class ExcluiPessoaCommand : IRequest<string>
{
    public int Id { get; set; }
}
