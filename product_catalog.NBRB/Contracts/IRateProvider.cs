
using product_catalog.NBRB.Models;

namespace product_catalog.NBRB.Contracts;

public interface IRateProvider
{
    Task<decimal> ConvertValueToCurrency(decimal value, string currency);
}
