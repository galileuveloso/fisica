using Fisica.Classes;
using Fisica.Domains;
using Fisica.Enums;
using Fisica.Interfaces;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.NoticiaFeature.Commands
{
    public class CadastrarNoticiaCommand : IRequest
    {
        public string? Conteudo { get; set; }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Conteudo)) throw new ArgumentNullException(MessageHelper.NullFor<CadastrarNoticiaCommand>(x => x.Conteudo));
        }
    }

    public class CadastrarNoticiaHandler : IRequestHandler<CadastrarNoticiaCommand>
    {
        private readonly IRepository<Noticia> _repositoryNoticia;
        private readonly IRepository<Usuario> _repositoryUsuario;

        public CadastrarNoticiaHandler(IRepository<Noticia> noticiaRepository, IRepository<Usuario> usuarioRepository)
        {
            _repositoryNoticia = noticiaRepository;
            _repositoryUsuario = usuarioRepository;
        }

        public async Task<Unit> Handle(CadastrarNoticiaCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<CadastrarNoticiaCommand>());

            request.Validar();

            Usuario usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario, cancellationToken);

            if (usuario.TipoUsuario != (int)TipoUsuario.Professor && usuario.TipoUsuario != (int)TipoUsuario.ProfessorAdministrador)
                throw new InvalidOperationException("Usuário não tem permissão para publicar noticias.");

            Noticia noticia = new()
            {
                AutorId = usuario.Id,
                DataCadastro = DateTime.Now,
                Conteudo = request.Conteudo!
            };

            await _repositoryNoticia.AddAsync(noticia, cancellationToken);
            await _repositoryNoticia.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
