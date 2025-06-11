using FluentValidation;
using FluentValidation.Results;

using EventRegistrationApi.Application.Abstractions.Services;
using EventRegistrationApi.Application.Dtos.Commands.Participants;
using EventRegistrationApi.Application.Extensions.Mappers;
using EventRegistrationApi.Domain.Abstractions.Repositories;
using EventRegistrationApi.Domain.Entities.Participants;

namespace EventRegistrationApi.Application.Services;

public class ParticipantService : IParticipantService
{
	private readonly IValidator<ParticipantDto> _ParticipantDtoValidator;

	private IParticipantRepository _ParticipantRepository;
	private readonly IUnitOfWork _unitOFWork;

	
	public ParticipantService(IValidator<ParticipantDto> ParticipantDtoValidator, IParticipantRepository ParticipantRepository, IUnitOfWork unitOfWork)
	{
		_ParticipantDtoValidator = ParticipantDtoValidator;
		_ParticipantRepository = ParticipantRepository;
		_unitOFWork = unitOfWork;
	}

	public async Task<(ValidationResult ValidationResult, int? ParticipantId)> AddParticipant(ParticipantDto Participant)
	{
		var validationResult = _ParticipantDtoValidator.Validate(Participant);
		if (validationResult.IsValid)
		{
			var repoResult = await _ParticipantRepository.AddParticipant(Participant.ConvertToDomainEntity());
			await _unitOFWork.CommitAsync();

			return (validationResult, repoResult.Id);
		}
		return (validationResult, null);
	}

	public async Task<ValidationResult> EditParticipant(ParticipantDto Participant)
	{
		var validationResult = _ParticipantDtoValidator.Validate(Participant);
		if (validationResult.IsValid)
		{
			Participant ParticipantEntity = null!;

			try
			{
				ParticipantEntity = await _ParticipantRepository.GetParticipant(Participant.Id);
			}
			catch (Domain.Exceptions.EntityNotFoundException ex)
			{
				throw new Application.Exceptions.EntityNotFoundException($"Unable to find an Participant with id {Participant.Id}.", ex);
			}

			ParticipantEntity.UpdateName(Participant.Name);
			ParticipantEntity.UpdateLastName(Participant.LastName);
            ParticipantEntity.UpdateEmail(Participant.Email);

            await _ParticipantRepository.EditParticipant(ParticipantEntity);
			await _unitOFWork.CommitAsync();
		}

		return validationResult;
	}

	public async Task DeleteParticipant(int ParticipantId)
	{
		await _ParticipantRepository.DeleteParticipant(ParticipantId);
		await _unitOFWork.CommitAsync();
	}
}
