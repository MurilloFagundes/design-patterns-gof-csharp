using System.Collections.ObjectModel;

namespace Csharp.Gof.Domain.Models
{
    public class Result
    {
        private static readonly IReadOnlyList<Error> EmptyErrors =
            new ReadOnlyCollection<Error>(Array.Empty<Error>());

        protected Result(bool isSuccess, IReadOnlyList<Error> errors)
        {
            if (isSuccess && errors.Count > 0)
                throw new InvalidOperationException("Success result cannot contain errors.");
            if (!isSuccess && errors.Count == 0)
                throw new InvalidOperationException("Failure result must contain at least one error.");

            IsSuccess = isSuccess;
            Errors = errors;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public IReadOnlyList<Error> Errors { get; }

        public Error? FirstError => Errors.Count > 0 ? Errors[0] : null;

        public static Result Success() => new(true, EmptyErrors);

        public static Result Failure(params Error[] errors)
            => new(false, new ReadOnlyCollection<Error>(errors ?? Array.Empty<Error>()));

        public static Result Failure(IEnumerable<Error> errors)
            => new(false, new ReadOnlyCollection<Error>((errors ?? Array.Empty<Error>()).ToArray()));

        public static Result Combine(params Result[] results)
        {
            var failures = results.Where(r => r.IsFailure).SelectMany(r => r.Errors).ToArray();
            return failures.Length == 0 ? Success() : Failure(failures);
        }

        public static Result Ensure(bool condition, Error error)
            => condition ? Success() : Failure(error);

        public Result Tap(Action action)
        {
            if (IsSuccess) action();
            return this;
        }

        public Result TapFailure(Action<IReadOnlyList<Error>> action)
        {
            if (IsFailure) action(Errors);
            return this;
        }

        public static implicit operator Result(Error error) => Failure(error);
        public static implicit operator Result(Error[] errors) => Failure(errors);
        public static implicit operator Result(List<Error> errors) => Failure(errors);
    }
}
