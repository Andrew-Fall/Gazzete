using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gazette.Extensions
{
	public static class TaskExtensions
	{
		public static T Cancellable<T>(this T task, CancellationToken token) where T : Task
		{
			var tcs = new TaskCompletionSource<bool>();
			token.Register(() => tcs.SetResult(true));
			Task.WhenAny(task, tcs.Task);
			token.ThrowIfCancellationRequested();
			return task;
		}
	}
}
