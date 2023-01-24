﻿using FisicaUsuario.Api.Helpers;
using FisicaUsuario.Classes;
using FisicaUsuario.Dados.Extensions;
using FisicaUsuario.Interfaces;
using MediatR;
using System.Data.Entity.Core;

namespace FisicaUsuario.Api.Features.UsuarioFeature.Commands
{
    public class LoginCommand : IRequest<Usuario>
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }

        public void Validate()
        {
            if (String.IsNullOrEmpty(Login)) throw new ArgumentNullException("Login não informado.");
            if (String.IsNullOrEmpty(Login)) throw new ArgumentNullException("Senha não informada.");
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Usuario>
    {
        private readonly IRepository<Usuario> _repository;

        public LoginCommandHandler(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<LoginCommand>());

            request.Validate();

            Usuario? usuario = await _repository.ObterUsuarioPorLogin(request.Login!, request.Senha!, cancellationToken);

            if (usuario is null)
                throw new ObjectNotFoundException(MessageHelper.NotFoundFor<Usuario>());

            return usuario;
        }
    }
}