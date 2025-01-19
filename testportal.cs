using WvsBeta.Game;

class Portal : IScriptV2 {
	public override void Run() {
		self.say("Yes?");
		ChangeMap(180000000);
	}

}