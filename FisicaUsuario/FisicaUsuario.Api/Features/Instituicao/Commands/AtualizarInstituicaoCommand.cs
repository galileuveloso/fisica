using FisicaUsuario.Api.Extensions;
using FisicaUsuario.Api.Helpers;
using FisicaUsuario.Classes;
using FisicaUsuario.Interfaces;
using MediatR;
using System.Data.Entity.Core;

namespace FisicaUsuario.Api.Features.InstituicaoFeature.Commands
{
    public class AtualizarInstituicaoCommand : IRequest
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public int Numero { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }

        public void Validate()
        {
            if (Id == 0) throw new ArgumentNullException("Instituição não informada.");
            if (String.IsNullOrEmpty(Nome)) throw new ArgumentNullException("Nome não informado.");
            if (String.IsNullOrEmpty(Descricao)) throw new ArgumentNullException("Descricao não informado.");
            if (String.IsNullOrEmpty(Email)) throw new ArgumentNullException("Email não informado.");
            if (String.IsNullOrEmpty(Site)) throw new ArgumentNullException("Site não informado.");
            if (String.IsNullOrEmpty(Logradouro)) throw new ArgumentNullException("Logradouro não informado.");
            if (String.IsNullOrEmpty(Bairro)) throw new ArgumentNullException("Bairro não informado.");
            if (String.IsNullOrEmpty(Cidade)) throw new ArgumentNullException("Cidade não informada.");
            if (String.IsNullOrEmpty(UF)) throw new ArgumentNullException("UF não informada.");
            if (Numero == 0) throw new ArgumentNullException("Numero não informado.");
        }
    }

    public class AtualizarInstituicaoHandler : IRequestHandler<AtualizarInstituicaoCommand>
    {
        private readonly IRepository<Instituicao> _repository;

        public AtualizarInstituicaoHandler(IRepository<Instituicao> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarInstituicaoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(MessageHelper.NullFor<AtualizarInstituicaoCommand>());

            request.Validate();

            Instituicao? instituicao = await _repository.GetSingleAsync(x => x.Id == request.Id);

            if (instituicao == null)
                throw new ObjectNotFoundException(MessageHelper.NotFoundFor<Instituicao>());

            instituicao.Atualizar(request);

            await _repository.UpdateAsync(instituicao);

            return await Unit.Task;
        }
    }
}
