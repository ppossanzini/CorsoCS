declare namespace Server {

  type GUID = String;

  interface CreateNote {
    date: Date;
    title: string;
    body: string;
  }


  interface Note {
    id: GUID;
    date: Date;
    title: string;
    body: string;
    flagged: boolean;
  }

  interface PagedResults<T> {
    count: number;
    currentPage: number;
    items: T[];
  }

}


