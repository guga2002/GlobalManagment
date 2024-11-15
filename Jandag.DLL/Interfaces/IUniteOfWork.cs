﻿using DatabaseOperations.Interfaces;
using Interfaces;
using Speaker.leison.Database_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace Jandag.DLL.Interfaces
{
    public interface IUniteOfWork:IDisposable
    {
        public IChanellRepository ChanellRepository { get; }
        public IDesclamlerCard desclamlerCardRepository { get; }
        public IDesclambler desclamblerRepository { get; }
        public IEmr60Info emr60InfoRepository { get; }
        public ISourceRepository sourceRepository { get; }
        public ITranscoderRepository transcoderRepository { get; }
        public ISatteliteFrequency satteliterFrequencyRepository { get; }
        Task CommitAndSavechanges();
    }
}
