using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;

namespace MediatrPoC.App
{
	public class ValidationBehavior<TRequest> : IRequestPreProcessor<TRequest>
		where TRequest : IBaseRequest
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public Task Process(
			TRequest request,
			CancellationToken cancellationToken)
		{
			var context = new ValidationContext(request);
			var failures = _validators
				.Select(v => v.Validate(context))
				.SelectMany(result => result.Errors)
				.Where(f => f != null)
				.ToList();

			if (failures.Any())
			{
				throw new ValidationException(failures);
			}

			return Task.CompletedTask;
		}
	}
}
