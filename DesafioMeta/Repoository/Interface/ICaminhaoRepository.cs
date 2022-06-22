using DesafioMeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Repoository.Interface
{
    public interface ICaminhaoRepository
    {
        CaminhaoModel Salvar(CaminhaoModel caminhao);
        List<CaminhaoModel> BuscarTodos();
        CaminhaoModel Atualizar(CaminhaoModel caminhao);
        void Deletar(long Id);
    }
}
