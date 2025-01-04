window.dragHelper = {
  startDrag: (dotNetRef) => {
    const handleMouseMove = (event) => {
      const deltaY = event.movementY;
      dotNetRef.invokeMethodAsync('HandleDrag', deltaY);
    };

    const handleMouseUp = () => {
      dotNetRef.invokeMethodAsync('StopDrag');
      document.removeEventListener('mousemove', handleMouseMove);
      document.removeEventListener('mouseup', handleMouseUp);
    };

    document.addEventListener('mousemove', handleMouseMove);
    document.addEventListener('mouseup', handleMouseUp);
  }
};

window.togglePencilIcon = (rowIndex, show) => {
  var rowElement = document.getElementById(`row-${rowIndex}`);
  if (rowElement) {
    var pencilIcon = rowElement.querySelector(".edit-icon");
    if (pencilIcon) {
      pencilIcon.style.display = show ? "block" : "none"; // Show or hide the pencil icon
    }
  }
};

