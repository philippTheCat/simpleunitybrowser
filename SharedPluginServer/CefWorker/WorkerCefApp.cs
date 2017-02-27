using Xilium.CefGlue;

namespace SharedPluginServer
{
    class WorkerCefApp : CefApp
    {
        private readonly WorkerCefRenderProcessHandler _renderProcessHandler;

        private bool _enableWebRtc = false;

        public WorkerCefApp(bool enableWebRtc)
        {
            _renderProcessHandler=new WorkerCefRenderProcessHandler();
            _enableWebRtc = enableWebRtc;

        }

        protected override CefRenderProcessHandler GetRenderProcessHandler()
        {
            return _renderProcessHandler;
        }





        //GPU and others
        protected override void OnBeforeCommandLineProcessing(string processType, CefCommandLine commandLine)
        {
            if (string.IsNullOrEmpty(processType))
            {
               // commandLine.AppendSwitch("enable-webrtc");
                commandLine.AppendSwitch("disable-gpu");
                commandLine.AppendSwitch("disable-gpu-compositing");
                commandLine.AppendSwitch("enable-begin-frame-scheduling");
                commandLine.AppendSwitch("disable-smooth-scrolling");
               if (_enableWebRtc)
                {
                    commandLine.AppendSwitch("enable-media-stream", "true");
                   
                }

            }
            //commandLine.AppendArgument("--enable-media-stream");
        }
    }
}