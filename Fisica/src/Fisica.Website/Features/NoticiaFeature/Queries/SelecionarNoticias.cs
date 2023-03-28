using Fisica.Classes;
using Fisica.Domains;
using Fisica.Interfaces;
using Fisica.Models;
using Fisica.Website.Extensions;
using Fisica.Website.Helpers;
using MediatR;

namespace Fisica.Website.Features.NoticiaFeature.Queries
{
    public class SelecionarNoticiasQuery : IRequest<IEnumerable<NoticiaModel>>
    {
    }

    public class SelecionarNoticiasHandler : IRequestHandler<SelecionarNoticiasQuery, IEnumerable<NoticiaModel>>
    {
        private readonly IRepository<Usuario> _repositoryUsuario;
        private readonly IRepository<Segue> _repositorySegue;

        public SelecionarNoticiasHandler(IRepository<Usuario> repositoryUsuario, IRepository<Segue> repositorySegue)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositorySegue = repositorySegue;
        }

        public async Task<IEnumerable<NoticiaModel>> Handle(SelecionarNoticiasQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(MessageHelper.NullFor<SelecionarNoticiasQuery>());

            Usuario usuario = await _repositoryUsuario.GetSingleAsync(x => x.Id == ControllerExtensions.IdUsuario, cancellationToken, x => x.Seguindo);

            //resolver o mapeamento de usuario - segue

            IEnumerable<Segue> segue = await _repositorySegue.GetAsync(x => x.UsuarioId == usuario.Id, cancellationToken, x => x.Professor.Noticias);

            IList<Noticia> noticias = new List<Noticia>();

            foreach (Segue seg in segue)
                foreach (Noticia noticia in seg.Professor.Noticias)
                    noticias.Add(noticia);

            return noticias.ToResponse();
        }
    }
}
