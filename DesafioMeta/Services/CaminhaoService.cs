using DesafioMeta.Models;
using DesafioMeta.Repoository.Interface;
using DesafioMeta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Services
{
    public class CaminhaoService : ICaminhaoService
    {
        private ICaminhaoRepository _repository;
        public CaminhaoService(ICaminhaoRepository repository)
        {
            _repository = repository;
        }

        public CaminhaoModel Atualizar(CaminhaoModel caminhao)
        {
            try
            {
                return _repository.Atualizar(caminhao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<CaminhaoModel> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Deletar(long Id)
        {
            try
            {
                _repository.Deletar(Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public CaminhaoModel Salvar(CaminhaoModel caminhao)
        {
            try
            {
                return _repository.Salvar(caminhao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
               
    }
}
