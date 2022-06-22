using DesafioMeta.Data;
using DesafioMeta.Models;
using DesafioMeta.Repoository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Repoository
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        private Contexto _context;
        public CaminhaoRepository(Contexto context)
        {
            _context = context;
        }

        public CaminhaoModel Atualizar(CaminhaoModel caminhao)
        {
            _context.Update(caminhao);
            _context.SaveChanges();

            return caminhao;
        }

        public List<CaminhaoModel> BuscarTodos()
        {
            return _context.Set<CaminhaoModel>().ToList();
        }

        public void Deletar(long Id)
        {
            CaminhaoModel model = new CaminhaoModel();
            model.Id = Id;
            
            _context.Remove<CaminhaoModel>(model);
            _context.SaveChanges();
        }

        public CaminhaoModel Salvar(CaminhaoModel caminhao)
        {
            _context.Update(caminhao);
            _context.SaveChanges();

            return caminhao;
        }
    }
}
