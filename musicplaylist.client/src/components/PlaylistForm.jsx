import { useState, useRef } from "react";

export default function PlaylistForm({ onAdd }) {
    const [title, setTitle] = useState("");
    const dialogRef = useRef();

    // ✅ Arrow functions - called on click, not on render
    const openDialog = () => dialogRef.current.showModal();
    const closeDialog = () => dialogRef.current.close();

    const handleSubmit = (e) => {
        e.preventDefault();

        if (!title.trim()) return;  // ✅ Don't submit empty titles

        onAdd({ title });
        setTitle("");
        closeDialog();
    };

    // ✅ Prevent form submission when clicking Cancel
    const handleCancel = (e) => {
        e.preventDefault();
        setTitle("");  // Reset form
        closeDialog();
    };

    return (
        <>
            <button className="btn btn-primary" onClick={openDialog}>
                New Playlist
            </button>

            <dialog ref={dialogRef}>
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label className="form-label">Title</label>
                        <input
                            className="form-control"
                            value={title}
                            onChange={(e) => setTitle(e.target.value)}
                            placeholder="Enter playlist name"
                        />
                        <div className="hstack gap-3 mt-3">
                            <button type="submit" className="btn btn-success">
                                Save
                            </button>
                            <button
                                type="button"  
                                className="btn btn-danger"
                                onClick={handleCancel}
                            >
                                Cancel
                            </button>
                        </div>
                    </div>
                </form>
            </dialog>
        </>
    );
}