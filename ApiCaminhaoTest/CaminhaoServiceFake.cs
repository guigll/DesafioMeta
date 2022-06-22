using DesafioMeta.Models;
using DesafioMeta.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiCaminhaoTest
{
    public class CaminhaoServiceFake : ICaminhaoService
    {
        private readonly List<CaminhaoModel> _model;
        public CaminhaoServiceFake()
        {
            _model = new List<CaminhaoModel>()
            {
                new CaminhaoModel() { Id = 1, Modelo = "FM",
                                   AnoFabricacao =2022, AnoModelo = 2022 },
                new CaminhaoModel() { Id = 2, Modelo = "FH",
                                   AnoFabricacao = 2022, AnoModelo = 2023 },
                new CaminhaoModel() { Id = 3, Modelo = "FH",
                                   AnoFabricacao = 2022, AnoModelo = 2022 },
                new CaminhaoModel() { Id = 4, Modelo = "FM",
                                   AnoFabricacao = 2022, AnoModelo = 2023 },

            };
        }
        public CaminhaoModel Atualizar(CaminhaoModel caminhao)
        {
            Deletar(caminhao.Id);
            _model.Add(caminhao);
            return caminhao;
        }

        public List<CaminhaoModel> BuscarTodos()
        {
            return _model;            
        }

        public bool Deletar(long id)
        {
            var quantidade = _model.Count();
            var item = _model.First(a => a.Id == id);
            _model.Remove(item);
            if (_model.Count() < quantidade)
            {
                return true;    
            }

            return false;
        }

        public CaminhaoModel Salvar(CaminhaoModel caminhao)
        {            
            caminhao.Id = GeraId();
            _model.Add(caminhao);
            return caminhao;
        }
        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}

