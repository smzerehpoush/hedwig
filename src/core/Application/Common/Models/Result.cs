using System;

namespace Application.Common.Models
{
    public class Result<TData>
    {
        public ResultStatus Status { get; }
        public TData? Data { get; }
        public Exception? Error { get; }

        public Result(ResultStatus status, TData data)
        {
            Status = status;
            Data = data;
        }

        public Result(ResultStatus status, Exception error)
        {
            Status = status;
            Error = error;
        }

        public Result(ResultStatus status)
        {
            Status = status;
        }

        public static Result<TData> Success(TData data)
        {
            return new Result<TData>(ResultStatus.Success, data);
        }

        public static Result<TData> Success()
        {
            return new Result<TData>(ResultStatus.Success);
        }

        public static Result<TData> Failure()
        {
            return new Result<TData>(ResultStatus.Failure);
        }

        public static Result<TData> Failure(Exception ex)
        {
            return new Result<TData>(ResultStatus.Failure);
        }


        public enum ResultStatus
        {
            Success,
            Failure,
        }
    }
}