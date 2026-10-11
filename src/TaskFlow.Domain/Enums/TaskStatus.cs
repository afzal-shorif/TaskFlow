enum TaskStatus
{
    None,
    Assigned, // We are consider this state as pending
    InProgress,
    OnHold,
    Completed,
    Deleted
}

// get next status truth table
// None => Assinged, Delete,
// Assigned => None, InProgress, Completed
// InProgress => OnHold, Completed, Assigned
// Completed =>
