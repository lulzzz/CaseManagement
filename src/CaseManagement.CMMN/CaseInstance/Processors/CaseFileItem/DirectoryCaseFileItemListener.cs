﻿using CaseManagement.CMMN.CaseInstance.Repositories;
using CaseManagement.CMMN.Domains;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CaseManagement.CMMN.CaseInstance.Processors.CaseFileItem
{
    public class DirectoryCaseFileItemListener : ICaseFileItemListener
    {
        private readonly ICaseFileItemRepository _caseFileItemRepository;

        public DirectoryCaseFileItemListener(ICaseFileItemRepository caseFileItemRepository)
        {
            _caseFileItemRepository = caseFileItemRepository;
        }

        public const string CASE_FILE_ITEM_TYPE = "https://github.com/simpleidserver/casemanagement/directory";
        public string CaseFileItemType => CASE_FILE_ITEM_TYPE;

        public async Task Start(ProcessorParameter parameter, CancellationToken token)
        {
            var tmpDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tmpDirectory);
            await _caseFileItemRepository.AddCaseFileItem(parameter.WorkflowElementInstance.Id, tmpDirectory);
            BuildTask(tmpDirectory, parameter, token);
        }

        private Task BuildTask(string directoryPath, ProcessorParameter processorParameter, CancellationToken token)
        {
            var task = new Task(() => HandleTask(directoryPath, processorParameter, token), token, TaskCreationOptions.LongRunning);
            task.Start();
            return task;
        }

        private void HandleTask(string directoryPath, ProcessorParameter processorParameter, CancellationToken token)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var fileSystemWatcher = new FileSystemWatcher
            {
                Path = directoryPath
            };
            fileSystemWatcher.Created += (s, e) => HandleFileCreated(processorParameter);
            fileSystemWatcher.EnableRaisingEvents = true;
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                try
                {
                    token.ThrowIfCancellationRequested();
                }
                catch
                {
                    cancellationTokenSource.Cancel();
                }
            }

            fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.Dispose();
        }

        private void HandleFileCreated(ProcessorParameter parameter)
        {
            parameter.WorkflowInstance.MakeTransition(parameter.WorkflowElementInstance.Id, CMMNTransitions.AddChild);
        }
    }
}
