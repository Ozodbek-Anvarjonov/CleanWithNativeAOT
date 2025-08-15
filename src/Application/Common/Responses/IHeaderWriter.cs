namespace Application.Common.Responses;

public interface IHeaderWriter
{
    void WritePaginationMetaData(PaginationMetaData paginationMetaData);
}
