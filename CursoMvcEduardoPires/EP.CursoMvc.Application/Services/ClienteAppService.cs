﻿using System;
using System.Collections.Generic;
using AutoMapper;
using EP.CursoMvc.Application.AutoMapper;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Models;
using EP.CursoMvc.Infra.Data.Repository;

namespace EP.CursoMvc.Application.Services
{
    public class ClienteAppService:IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }
        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = AutoMapperSingleton.GetInstance().Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = AutoMapperSingleton.GetInstance().Map<Endereco>(clienteEnderecoViewModel.Endereco);
            cliente.Enderecos.Add(endereco);
            _clienteRepository.Adicionar(cliente);
            return clienteEnderecoViewModel;
        }
        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = AutoMapperSingleton.GetInstance().Map<Cliente>(clienteViewModel);

            _clienteRepository.Atualizar(cliente);
            return clienteViewModel;
        }


        public ClienteViewModel ObterPorId(Guid id)
        {
            return AutoMapperSingleton.GetInstance()
                .Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return AutoMapperSingleton.GetInstance()
                .Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return AutoMapperSingleton.GetInstance()
                .Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return AutoMapperSingleton.GetInstance()
                .Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return AutoMapperSingleton.GetInstance()
                .Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        
        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
