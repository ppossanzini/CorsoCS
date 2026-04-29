

class NoteService {

  public async getNotes(
    title: string | null = null,
    body: string | null = null,
    pageNumber: number = 0,
    pageSize: number = 10
  ):
    Promise<Server.PagedResults<Server.Note>> {
    const response = await fetch(`${serviceConfig.baseUrl}/api/notes/search?title=${title}&body=${body}&page=${pageNumber}&pageSize=${pageSize}`);
    const data = await response.json();
    return data;
  }

  public async getNote(id: Server.GUID):
    Promise<Server.Note> {
    const response = await fetch(`${serviceConfig.baseUrl}/api/notes/${id}`);
    const data = await response.json();
    return data;
  }

  public async createNote(note: {
    date: Date;
    title: string;
    body: string;
  }):
    Promise<Server.GUID> {

    const response = await fetch(`${serviceConfig.baseUrl}/api/notes`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(note)
    });
    const data = await response.json();
    return data;
  }

}

export const noteService = new NoteService();


class ServiceConfig {
  baseUrl: string = 'http://localhost:5213';
}

const serviceConfig = new ServiceConfig();