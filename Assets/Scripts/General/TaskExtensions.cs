using UnityEngine;
using System;
using System.Threading.Tasks;

public static class TaskExtensions
{
    public static async void LogExceptions(this Task task)
    {
        try
        {
            await task;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}