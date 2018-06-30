using Core.Model;
using System.Collections.Generic;

namespace Core.Boundaries
{
    public interface ITaskRepository
    {
        int GetTotalCount();
        ISet<Task> GetTaskFor(User user);
    }
}