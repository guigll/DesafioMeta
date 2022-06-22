using DesafioMeta.Controllers;
using DesafioMeta.Models;
using DesafioMeta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ApiCaminhaoTest
{
    public class CaminhaoControllerTest
    {
        CaminhaoController _controller;
        ICaminhaoService _service;
        public CaminhaoControllerTest()
        {
            _service = new CaminhaoServiceFake();
            _controller = new CaminhaoController(_service);
        }

        [Fact]
        public void BuscarTodos()
        {            
            var okResult = _controller.BuscarTodos();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Salvar()
        {
            CaminhaoModel model = new CaminhaoModel()
            {                
                Modelo = "FM",
                AnoFabricacao = 2022,
                AnoModelo = 2022
            };
            var okResult = _controller.Salvar(model);

            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Atualizar()
        {
            CaminhaoModel model = new CaminhaoModel()
            {
                Id = 2,
                Modelo = "FM",
                AnoFabricacao = 2022,
                AnoModelo = 2022
            };
            var okResult = _controller.Atualizar(model);

            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void Deletar()
        {            
            var okResult = _controller.Deletar(1);

            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
