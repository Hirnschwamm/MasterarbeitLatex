using System;
using System.Threading.Tasks;
using MCCSharedFiles.GeneralDefinitions;
using ilogixx.MediaManager;

namespace ilogixx.ConversationRouting.Behavior.API{
  public class GeneratedConversationRoutingBehavior : ACDCallRoutingBehaviorBase{
    private class UserCode{
      
	  IPredefinedVariables _predefinedVariables;
      private string Skill{
        get{ return _predefinedVariables.Skill; }
        set{ _predefinedVariables.Skill = (value); }
      }

      private string Language{
        get { return _predefinedVariables.Language; }
        set { _predefinedVariables.Language = (value); }
      }

      public UserCode(IPredefinedVariables predefinedVariables){
        _predefinedVariables = (predefinedVariables);
      }

      public bool BranchNode__8298603678964f7f930a7fe3c78de201(){
        return Language != "Deutsch";
      }
    }

    private UserCode _userCode;
	
    public GeneratedConversationRoutingBehavior(IRoutedAcdCall conversation, 
		IReadOnlyRepository<string, Struct_Skill> skillRepository, 
		IReadOnlyRepository<string, Struct_Language> languageRepository)
		: base (conversation, skillRepository, languageRepository){
      _userCode = (new UserCode(PredefinedVariables));
    }

    private async Task TerminateNode__b913a2616fcd4eae99e5bb8e5346c7e6(){
      await base.Conversation.TerminateAsync();
    }

    private async Task DeliverNode__cc9e4bdc12b84e25a1cd561c307569c2(){
      await base.Conversation.DeliverAsync("sip:sachbearbeiter@SipServer");
    }

    private async Task BranchNode__8298603678964f7f930a7fe3c78de201(){
      bool expressionResult = 
	    _userCode.BranchNode__8298603678964f7f930a7fe3c78de201();
      if (expressionResult){
          await TerminateNode__b913a2616fcd4eae99e5bb8e5346c7e6();
      }else{
          await DeliverNode__cc9e4bdc12b84e25a1cd561c307569c2();
      }
    }

    public override async Task StartAsync(){
      await BranchNode__8298603678964f7f930a7fe3c78de201();
    }

    public override async Task VirtualStartAsync(){
      StartAsync();
    }
  }
}
