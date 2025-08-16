using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Csharp.Gof.Domain.Models
{
    public sealed class Result<T> : Result
    {
        private readonly T? _value;

        private Result(T? value, bool isSuccess, IReadOnlyList<Error> errors) : base(isSuccess, errors)
            => _value = value;

        [NotNull]
        public T Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("Result has no value (failure).");

        public bool TryGetValue([MaybeNullWhen(false)] out T value)
        {
            if (IsSuccess)
            {
                value = _value!;
                return true;
            }
            value = default!;
            return false;
        }

        public static Result<T> Success(T value)
            => new(value, true, Array.Empty<Error>());

        public static Result<T> Failure(params Error[] errors)
            => new(default, false, new ReadOnlyCollection<Error>(errors ?? Array.Empty<Error>()));

        public static Result<T> Failure(IEnumerable<Error> errors)
            => new(default, false, new ReadOnlyCollection<Error>((errors ?? Array.Empty<Error>()).ToArray()));

        public static Result<T> Create(T? value, Error whenNull)
            => value is null ? Failure(whenNull) : Success(value);

        // Funcionais
        public Result<K> Map<K>(Func<T, K> mapper)
            => IsSuccess ? Result<K>.Success(mapper(Value)) : Result<K>.Failure(Errors);

        public Result<K> Bind<K>(Func<T, Result<K>> binder)
            => IsSuccess ? binder(Value) : Result<K>.Failure(Errors);

        public KOut Match<KOut>(Func<T, KOut> onSuccess, Func<IReadOnlyList<Error>, KOut> onFailure)
            => IsSuccess ? onSuccess(Value) : onFailure(Errors);

        public Result<T> Ensure(Func<T, bool> predicate, Error error)
            => IsSuccess && !predicate(Value) ? Failure(error) : this;

        public Result<T> Tap(Action<T> action)
        {
            if (IsSuccess) action(Value);
            return this;
        }

        // Conversões implícitas para ergonomia
        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator Result<T>(Error error) => Failure(error);
        public static implicit operator Result<T>(Error[] errors) => Failure(errors);
        public static implicit operator Result<T>(List<Error> errors) => Failure(errors);
    }
}
