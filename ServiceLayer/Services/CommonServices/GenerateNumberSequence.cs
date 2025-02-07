using DomainLayer.Models;
using ServiceLayer.Services.IRepositories;
namespace ServiceLayer.Services.CommonServices
{
    public class GenerateNumberSequence : IGenerateNumberSequence
    {
        private readonly IUnitOfWork _context;

        public GenerateNumberSequence(IUnitOfWork context)
        {
            _context = context;
        }

        public string GetNumberSequence(string module)
        {
            string result = "";
            //try
            //{
            //    int counter = 0;

            //    var numberSequence = _context.NumberSequence.Get(x => x.Module.Equals(module));
            //    Interlocked.Increment(ref counter);

            //    if (numberSequence == null)
            //    {
            //        numberSequence.Module = module;
            //        numberSequence.LastNumber = counter;
            //        numberSequence.NumberSequenceName = module;
            //        numberSequence.Prefix = module;
                    
            //        _context.NumberSequence.Add(numberSequence);
            //        _context.Save();
            //    }
            //    else
            //    {
            //        counter = numberSequence.LastNumber;
            //        numberSequence.LastNumber = counter;

            //        _context.NumberSequence.Update(numberSequence);
            //        _context.Save();
            //    }

            //    result = counter.ToString().PadLeft(5, '0') + "#" + numberSequence.Prefix;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return result;
        }

    }
}
