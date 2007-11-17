using System;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;
using CPU = Indy.IL2CPU.Assembler.X86;

namespace Indy.IL2CPU.IL.X86 {
	[OpCode(Code.And)]
	public class And: Op {
		public And(Mono.Cecil.Cil.Instruction aInstruction, MethodInformation aMethodInfo)
			: base(aInstruction, aMethodInfo) {
		}
		public override void DoAssemble() {
			int xSize = Math.Max(Assembler.StackSizes.Pop(), Assembler.StackSizes.Pop());
			new CPU.Pop("eax");
			new CPU.Pop("edx");
			new CPU.And("eax", "edx");
			new CPU.Pushd("eax");
			Assembler.StackSizes.Push(xSize);
		}
	}
}