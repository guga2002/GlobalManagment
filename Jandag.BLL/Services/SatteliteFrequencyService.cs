using AutoMapper;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.BLL.Models.ViewModels;
using Jandag.DLL.Entities;
using Jandag.DLL.Interfaces;

namespace Jandag.BLL.Services
{
    public class SatteliteFrequencyService : AbstractService, ISatteliteFrequencyService
    {
        public SatteliteFrequencyService(IMapper map, IUniteOfWork wor) : base(map, wor)
        {
        }

        public async Task<bool> AddAsync(SatteliteFrequencyModel Item)
        {
            try
            {
                List<Source> chan = new List<Source>();

                var chanIds = Item.chanellIds.Split(',');

                foreach (var it in chanIds)
                {
                    var chane=await  work.sourceRepository.GetBychanellName(it.ToLower());
                    if (chane is not null)
                        chan.Add(chane);
                }
                var sattelit = new SatteliteFrequency()
                {
                    Sources = chan,
                    Degree = Item.Degree,
                    Frequency = Item.Frequency,
                    Polarisation = Item.Polarisation,
                    SymbolRate = Item.SymbolRate,
                    PortIn250 = Item.PortIn250,
                };
                await work.satteliterFrequencyRepository.Add(sattelit);
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await work.satteliterFrequencyRepository.Remove(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SatteliteFrequencyModel>> GetAllAsync()
        {
            try
            {
                var res = await work.satteliterFrequencyRepository.GetAll();

                List<SatteliteFrequencyModel> mod = new List<SatteliteFrequencyModel>();

                foreach (var item in res)
                {
                    mod.Add(new SatteliteFrequencyModel()
                    {
                        Frequency = item.Frequency,
                        Polarisation = item.Polarisation,
                        SymbolRate = item.SymbolRate,
                        PortIn250 = item.PortIn250,
                    });
                }
                return mod;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(SatteliteFrequencyModel item)
        {
            try
            {
                var res = new SatteliteFrequency()
                {
                    Frequency = item.Frequency,
                    Polarisation = item.Polarisation,
                    SymbolRate = item.SymbolRate,
                    PortIn250 = item.PortIn250,
                };
                await work.satteliterFrequencyRepository.Update(res);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SatteliteViewMonitoring>> GetMonitoringFrequencies()
        {
            try
            {
                var res = await work.satteliterFrequencyRepository.GetAll();

                var groupedByDegree = res.GroupBy(item => item.Degree);

                List<SatteliteViewMonitoring> monitor = new List<SatteliteViewMonitoring>();

                foreach (var group in groupedByDegree)
                {
                    SatteliteViewMonitoring mon = new SatteliteViewMonitoring();
                    mon.Degree = group.Key;
                    mon.details = new List<SatteliteFrequencyModel>();

                    foreach (var item in group)
                    {
                        mon.details.Add(new SatteliteFrequencyModel()
                        {
                            HaveError = false,
                            PortIn250 = item.PortIn250,
                            Frequency = item.Frequency,
                            Polarisation = item.Polarisation,
                            SymbolRate = item.SymbolRate,
                          
                        });
                    }

                    monitor.Add(mon);
                }

                return monitor;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //SatteliteFrequencyModel

        public async Task<SatteliteFrequencyModel> GetDetailsByEmrport(int PortId)
        {
            SatteliteFrequencyModel sat = new SatteliteFrequencyModel();
            var de = await work.satteliterFrequencyRepository.GetById(PortId);
            if (de is not null)
            {


                sat.Polarisation = de.Polarisation;
                sat.Frequency = de.Frequency;
                sat.SymbolRate = de.SymbolRate;
                sat.Degree = de.Degree;
                sat.PortIn250 = PortId;
                foreach (var item in de.Sources)
                {
                    //if (item.chanell is not null)
                    ///{
                        var chan = new ChanellModel()
                        {
                            Name = item.chanell.Name,

                        };
                        foreach (var it in item.chanell.Sources)
                        {
                            chan.Sources.Add(new SourceModel()
                            {
                                ChanellFormat = it.ChanellFormat,
                                Status = it.Status
                            });
                        }
                        sat.chanellid.Add(chan);
                   // }
                }
            }
            return sat;
        }
    }
}
