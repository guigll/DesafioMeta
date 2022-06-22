using DesafioMeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Services.Interfaces
{
    public interface ICaminhaoService
    {
        List<CaminhaoModel> BuscarTodos();
        CaminhaoModel Salvar(CaminhaoModel caminhao);
        CaminhaoModel Atualizar(CaminhaoModel caminhao);
        bool Deletar(long Id);
    }
}
