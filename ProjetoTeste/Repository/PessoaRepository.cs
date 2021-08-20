using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PessoaRepository : IRepository<Pessoa>
{
    private static Dictionary<int, Pessoa> pessoas = new Dictionary<int, Pessoa>();

    public async Task<IEnumerable<Pessoa>> GetAll(){
        return await Task.Run(() => pessoas.Values.ToList());
    }

    public async Task<Pessoa> Get(int id){
        return await Task.Run(() => pessoas.GetValueOrDefault(id));
    }

    public async Task Add(Pessoa pessoa){
        await Task.Run(() => {
            int id = 0;
            var pessoaTemp = pessoas.Values.Take(1).FirstOrDefault();
            if(pessoaTemp != null){
                id = pessoaTemp.Id + 1;
            }
            pessoas.Add(id, pessoa);});
    }

    public async Task Edit(Pessoa pessoa){
        await Task.Run(() =>
        {
            pessoas.Remove(pessoa.Id);
            pessoas.Add(pessoa.Id, pessoa);
        });
    }

    public async Task Delete(int id){
        await Task.Run(() => pessoas.Remove(id));
    }
}