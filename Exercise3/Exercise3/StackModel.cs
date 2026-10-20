using System;
using System.Collections.Generic;

namespace Exercise3
{
    public static class StackModel
    {
        public enum StepOp { Push, Pop }
        public class Step
        {
            public StepOp Op { get; set; }
            public int N { get; set; }
            public int Q { get; set; }
            public int R { get; set; }
        }

        // Produce ordered steps: pushes for each division, then pops
        public static List<Step> CreateSteps(int n)
        {
            var steps = new List<Step>();
            if (n == 0)
            {
                steps.Add(new Step { Op = StepOp.Push, N = 0, Q = 0, R = 0 });
                steps.Add(new Step { Op = StepOp.Pop });
                return steps;
            }
            int cur = n;
            var stack = new List<int>();
            while (cur > 0)
            {
                int q = cur / 2;
                int r = cur % 2;
                steps.Add(new Step { Op = StepOp.Push, N = cur, Q = q, R = r });
                stack.Add(r);
                cur = q;
            }
            // after dividing, add pop steps equal to stack size
            for (int i = 0; i < stack.Count; i++) steps.Add(new Step { Op = StepOp.Pop });
            return steps;
        }
    }
}
